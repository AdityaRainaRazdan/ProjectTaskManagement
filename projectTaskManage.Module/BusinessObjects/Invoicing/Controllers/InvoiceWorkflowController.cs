using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using projectTaskManage.Module.BusinessObjects;
using System;
using System.Linq;

public class InvoiceWorkflowController : ObjectViewController<DetailView, Invoice>
{
    SimpleAction submit;
    SimpleAction approve;
    SimpleAction reject;

    public InvoiceWorkflowController()
    {
        // --- Submit Action ---
        submit = new SimpleAction(this, "SubmitInvoice", "InvoiceActions")
        {
            Caption = "Submit"
        };
        submit.Execute += (_, __) => ChangeStatus(InvoiceStatus.Submitted, ApprovalAction.Submitted);

        // --- Approve Action ---
        approve = new SimpleAction(this, "ApproveInvoice", "InvoiceActions")
        {
            Caption = "Approve"
        };
        approve.Execute += (_, __) => ChangeStatus(InvoiceStatus.Approved, ApprovalAction.Approved);

        // --- Reject Action ---
        reject = new SimpleAction(this, "RejectInvoice", "InvoiceActions")
        {
            Caption = "Reject"
        };
        reject.Execute += (_, __) => ChangeStatus(InvoiceStatus.Rejected, ApprovalAction.Rejected);
    }

    protected override void OnActivated()
    {
        base.OnActivated();
        UpdateActions();
        UpdateEditMode();
    }

    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        UpdatePropertyEditors();
    }

    private void UpdateActions()
    {
        var invoice = View.CurrentObject as Invoice;
        if (invoice == null) return;

        submit.Active["DraftOnly"] = invoice.Status == InvoiceStatus.Draft;
        approve.Active["SubmittedOnly"] = invoice.Status == InvoiceStatus.Submitted;
        reject.Active["SubmittedOnly"] = invoice.Status == InvoiceStatus.Submitted;
    }

    private void UpdateEditMode()
    {
        var invoice = View.CurrentObject as Invoice;
        if (invoice == null) return;

        // Editable only if Draft
        View.ViewEditMode = invoice.Status == InvoiceStatus.Draft
            ? ViewEditMode.Edit
            : ViewEditMode.View;
    }

    private void UpdatePropertyEditors()
    {
        var invoice = View.CurrentObject as Invoice;
        if (invoice == null) return;

        // Make all properties read-only if not Draft
        bool editable = invoice.Status == InvoiceStatus.Draft;
        foreach (var item in View.Items)
        {
            if (item is PropertyEditor editor)
            {
                editor.AllowEdit.SetItemValue("WorkflowRule", editable);
            }
        }
    }

    private void ChangeStatus(InvoiceStatus status, ApprovalAction action)
    {
        var invoice = View.CurrentObject as Invoice;
        if (invoice == null) return;

        // --- Update Status ---
        invoice.Status = status;

        // --- Create Approval History ---
        var history = ObjectSpace.CreateObject<InvoiceApprovalHistory>();
        history.Invoice = invoice;
        history.Action = action.ToString();
        history.ActionDate = DateTime.Now;

        // Link to performing employee
        var user = SecuritySystem.CurrentUser as ApplicationUser;
        history.PerformedBy = ObjectSpace
            .GetObjects<Employee>()
            .FirstOrDefault(e => e.User == user);

        ObjectSpace.CommitChanges();

        // Refresh view and actions
        View.Refresh();
        UpdateActions();
        UpdateEditMode();
        UpdatePropertyEditors();
    }
}

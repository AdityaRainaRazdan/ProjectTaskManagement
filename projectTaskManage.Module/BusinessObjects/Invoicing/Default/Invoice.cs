using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;
using Microsoft.EntityFrameworkCore;

[DefaultClassOptions]
[Browsable(true)]
public class Invoice : BaseObject
{
    public virtual string InvoiceNumber { get; set; }

    public virtual DateTime InvoiceDate { get; set; } = DateTime.Now;

    public virtual InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;

    [Association("Invoice-LineItems")]
    public virtual ICollection<InvoiceLineItem> LineItems { get; set; }
    = new ObservableCollection<InvoiceLineItem>();

    [Association("Invoice-ApprovalHistory")]
    public virtual ICollection<InvoiceApprovalHistory> ApprovalHistory { get; set; }
        = new ObservableCollection<InvoiceApprovalHistory>();


    [NotMapped]
    [DevExpress.ExpressApp.DC.PersistentAlias("LineItems.Sum(IsNull(Quantity, 0) * IsNull(UnitPrice, 0))")]
    [Precision(18, 2)]
    public decimal SubTotal => Convert.ToDecimal(SubTotal);

    [NotMapped]
    [DevExpress.ExpressApp.DC.PersistentAlias("SubTotal * 0.18")]
    [Precision(18, 2)]
    public decimal Tax => Convert.ToDecimal(Tax);

    [NotMapped]
    [DevExpress.ExpressApp.DC.PersistentAlias("SubTotal + Tax")]
    [Precision(18, 2)]
    public decimal Total => Convert.ToDecimal(Total);
}

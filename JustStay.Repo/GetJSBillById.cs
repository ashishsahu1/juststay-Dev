
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace JustStay.Repo
{

using System;
    
public partial class GetJSBillById
{

    public int JSBillId { get; set; }

    public Nullable<int> ATRCId { get; set; }

    public Nullable<System.DateTime> BillFrom { get; set; }

    public Nullable<System.DateTime> BillTo { get; set; }

    public string BillNo { get; set; }

    public Nullable<System.DateTime> BillDate { get; set; }

    public string PaymentBy { get; set; }

    public string Description { get; set; }

    public Nullable<decimal> TotalAmount { get; set; }

    public Nullable<decimal> PaidAmount { get; set; }

    public Nullable<bool> IsPaid { get; set; }

    public Nullable<System.DateTime> PaidDate { get; set; }

    public Nullable<System.DateTime> InsertedOn { get; set; }

    public Nullable<System.DateTime> UpdatedOn { get; set; }

    public Nullable<bool> IsDeleted { get; set; }

    public Nullable<decimal> BalanceAmount { get; set; }

}

}

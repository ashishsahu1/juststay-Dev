
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
    using System.Collections.Generic;
    
public partial class CancellationPolicy
{

    public int PolicyId { get; set; }

    public string PolicyName { get; set; }

    public byte PolicyType { get; set; }

    public string Details { get; set; }

    public string FromTime { get; set; }

    public string ToTime { get; set; }

    public bool ApplyAfterBooking { get; set; }

    public bool ApplyBeforeCheckIn { get; set; }

    public decimal RefundPercentage { get; set; }

}

}

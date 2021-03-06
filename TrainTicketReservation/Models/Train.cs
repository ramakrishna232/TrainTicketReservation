//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainTicketReservation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Train
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Train()
        {
            this.TrainFares = new HashSet<TrainFare>();
        }
    
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public int ACTier_3 { get; set; }
        public int ACTier_2 { get; set; }
        public int ACTier_1 { get; set; }
        public int SLAvailable { get; set; }
        public int SSAvailable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainFare> TrainFares { get; set; }
    }
}

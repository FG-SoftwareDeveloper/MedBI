namespace MedBI.ClientSide.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Diagnosis { get; set; }
        public string ProcedureCode { get; set; }
        public string Status { get; set; }
        public DateTime DateOfService { get; set; }
        public decimal Amount { get; set; }
    }
}

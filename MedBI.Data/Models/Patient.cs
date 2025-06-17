using System.Collections.Generic;

namespace MedBI.Data.Models;

public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}

﻿        namespace Domain;

public class Customer
{
    public int Id { get; set; }
    public int IdentificationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public ICollection<Order> Orders{ get; set; }


}

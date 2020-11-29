export class RegistrationModel {
    constructor() {
        this.Id = null;
        this.FirstName = '';
        this.LastName = '';
        this.Gender = '';
        this.MobileNo = '';
        this.Email = '';
        this.Password = '';
        this.ConfirmPassword = '';
        this.Role = '';
        this.Status = '';
        this.CreatedOn = null;
    }
    Id: number;
    FirstName: string;
    LastName: string;
    Gender: string;
    MobileNo: string;
    Email: string;
    Password: string;
    ConfirmPassword: string;
    Role: string;
    Status: string;
    CreatedOn: Date;
}

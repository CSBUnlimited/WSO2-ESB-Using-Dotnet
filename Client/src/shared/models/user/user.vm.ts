
export interface UserVM {
    id?: number;
    firstName?: string;
    lastName?: string;
    email?: string;
    mobile?: string;
    gender?: number;
    loyaltyPoints?: number;
    registeredDate?: Date;
    
    payments?: any[];
    confirmEmails?: any[];
    confirmSMSes?: any[];
}
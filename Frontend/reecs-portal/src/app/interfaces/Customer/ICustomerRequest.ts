export interface ICustomerRequest {
  custName: string;
  custAddress: string;
  createdDate?: string; // ISO string format (optional - defaults on backend)
  createdBy: string;
  custFullName: string;
  archived?: string; // optional, since backend may default to empty string
  demandMw: number;
  regPrice: number;
}

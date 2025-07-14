export interface IUpdateCustomerRequest {
  custCode: number;

  custName?: string;
  custAddress?: string;
  modifiedBy?: string;

  // Use string format (e.g., "2025-07-14") for DateOnly
  modifiedDate?: string;

  custFullName?: string;
  archived?: string; // Defaults to "0" on backend

  demandMw?: number;
  regPrice?: number;
}

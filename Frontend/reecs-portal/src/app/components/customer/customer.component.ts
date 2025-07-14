import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICustomerRequest } from '../../interfaces/Customer/ICustomerRequest';
import { CustomerService } from '../../services/customer/customer.service';
import { ICustomerResponse } from '../../interfaces/Customer/ICustomerResponse';
import { IUpdateCustomerRequest } from '../../interfaces/Customer/IUpdateCustomerRequest';

@Component({
  selector: 'app-customer',
  imports: [FormsModule,CommonModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {

  public customerList : ICustomerResponse[] = []

  isLoading = false;
  showModal = false;
  showModal2 = false;

  customerResponseObj : ICustomerResponse = {
    custCode : 0,
    custName : "",
    custAddress : "",
    demandMw : 0,
    regPrice : 0,
  }

  customerObj: ICustomerRequest = {
  custName: '',
  custAddress: '',
  createdDate: Date(), 
  createdBy: '',
  custFullName: '',
  archived: '0',           // optional, but you can default it
  demandMw: 0,
  regPrice: 0
};
  updateCustomerObj: IUpdateCustomerRequest = {
  custCode: 0,          
  custName: '',
  custAddress: '',
  modifiedBy: '',
  modifiedDate: '',    
  custFullName: '',
  archived: '0',        // Default to "0"
  demandMw: 0,
  regPrice: 0
};



  customerService = inject(CustomerService);

  ngOnInit(): void {
    this.getAllCustomers();
  }

  openEditModal(customer: ICustomerResponse) {
  this.updateCustomerObj = {
    custCode: customer.custCode,
    custName: customer.custName,
    custAddress: customer.custAddress,
    modifiedBy: '', 
    modifiedDate: new Date().toISOString().split('T')[0], 
    custFullName: '', 
    archived: '0',
    demandMw: customer.demandMw ?? 0,
    regPrice: customer.regPrice ?? 0
  };
  this.showModal2 = true;
}
  

  getAllCustomers(){
    this.customerService.getAllCustomers().subscribe({
      next:(res) => {
        this.customerList =  res;
    },
    error: (err)=> console.error('error fetching customers',err)
    });
  }

  createCustomer(){
    this.customerService.createCustomer(this.customerObj).subscribe({
      next: (res) => {
        this.isLoading = true;
        setTimeout(() => {
          this.showModal = false;
          this.isLoading = false;
          console.log('Created!', res);
        }, 1000);
      },
      error: (err) => {
        console.error('Validation errors:', err.error.errors); // 👈 log exact issue
      }
    })
  }

  updateCustomer() {
    console.log("Updating with:", this.updateCustomerObj);
  this.customerService.updateCustomer( this.updateCustomerObj.custCode,this.updateCustomerObj ).subscribe({
    next: () => {
      console.log("Customer updated successfully!");
      this.getAllCustomers();
      alert("Update Customer Success");
      this.showModal2 = false;
    },
    error: (err) => {
      console.error('Validation errors:', err.error.errors);
    }
  });
}


  deleteCustomer(custCode:number) {
    if (!custCode || custCode <= 0) {
      console.error('Invalid customer code.');
      return;
    }

    if (!confirm("Are you sure you want to delete this customer?")) {
      return;
    }

    this.customerService.deleteCustomer(custCode).subscribe({
      next: () => {
        console.log("Customer deleted successfully!");
        this.getAllCustomers(); // Refresh the list
      },
      error: (err) => {
        console.error('Delete failed:', err);
      }
    });
  }

}

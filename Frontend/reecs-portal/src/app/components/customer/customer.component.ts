import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICustomer } from '../../interfaces/ICustomer';
import { CustomerService } from '../../services/customer/customer.service';

@Component({
  selector: 'app-customer',
  imports: [FormsModule,CommonModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {

  public customerList : ICustomer[] = []

  isLoading = false;
  showModal = false;
  showModal2 = false;

  customerObj : ICustomer = {
    custCode : 0,
    custName : "",
    custAddress : "",
    demandMw : 0,
    regPrice : 0,
  }

  customerService = inject(CustomerService);

  ngOnInit(): void {
    this.getAllCustomers();
  }

  openEditModal(customer: ICustomer) {
      this.customerObj = { ...customer};
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

}

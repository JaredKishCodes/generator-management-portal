import { Component, inject, OnInit } from '@angular/core';
import { GeneratorService } from '../../services/generator.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Gen } from '../../interfaces/generator';

@Component({
  selector: 'app-home',
  imports: [CommonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  public generatorsList: Gen[] = []
  isLoading = false;
  showModal = false;
  showModal2 = false;

  generatorObj: Gen = {
    genCode: 0,
    genName: '',
    genAddress: '',
    capacityMw: 0,
    regPrice: 0,
  }

  generatorService = inject(GeneratorService);

  ngOnInit() {
    this.getGenerators()
  }

  getGenerators() {
    this.generatorService.getAllGenerators().subscribe({
      next: (res) => this.generatorsList = res
    })
  }

  createGenerator() {
    this.generatorService.createGenerator(this.generatorObj).subscribe({
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
    });
  }

  editGenerator() {
    this.generatorService.updateGenerator(this.generatorObj.genCode, this.generatorObj).subscribe({
      next: () => {
        console.log('Payload before PUT:', this.generatorObj);
        console.log("Generator updated successfully!")
        this.getGenerators()
        alert("Update Generator Success")
        this.showModal2 = false;
      },
      error: (err) => {
        console.error('Validation errors:', err.error.errors);
      }
    })
  }

  deleteGenerator(genCode: number) {
    if (!genCode || genCode <= 0) {
      console.error('Invalid generator code.');
      return;
    }

    if (!confirm("Are you sure you want to delete this generator?")) {
      return;
    }

    this.generatorService.deleteGenerator(genCode).subscribe({
      next: () => {
        console.log("Generator deleted successfully!");
        this.getGenerators(); // Refresh the list
      },
      error: (err) => {
        console.error('Delete failed:', err);
      }
    });
  }





  openEditModal(gen: Gen) {
    this.generatorObj = { ...gen };
    this.showModal2 = true;
  }


}

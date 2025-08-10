import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.models';// Import the interface for type safety
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;// Initialize the model with default values
  private addCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService,
    private router: Router) {
    this.model = {
      name: '',
      urlHandle: ''
    };
  }

  onFormSubmit() {
    this.addCategorySubscription = this.categoryService.AddCategory(this.model)
      .subscribe({//subscribe to the observable returned by the service
        next: (response) => {
          this.router.navigateByUrl('/admin/category');// Navigate to the category list after successful addition
        }
      })
    }
    // It unsubscribes from the addCategorySubscription to prevent memory leaks
  ngOnDestroy(): void {
      this.addCategorySubscription?.unsubscribe();
    }
}

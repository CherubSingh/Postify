import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.models';// Import the interface for type safety
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;// Initialize the model with default values
  private addCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService) {
    this.model = {
      name: '',
      urlHandle: ''
    };
  }

  
  
    onFormSubmit() {
      this.addCategorySubscription = this.categoryService.AddCategory(this.model)
      .subscribe({//subscribe to the observable returned by the service
        next: () => {
          console.log('Category added successfully');
        },
        error: (err) => {
          console.error('Error adding category:', err);
        }

      })
    }
    // It unsubscribes from the addCategorySubscription to prevent memory leaks
    ngOnDestroy(): void {
      this.addCategorySubscription?.unsubscribe();
    }
}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { BlogpostListComponent } from './features/blog_post/blogpost-list/blogpost-list.component';
import { AddBlogpostComponent } from './features/blog_post/add-blogpost/add-blogpost.component';

const routes: Routes = [
  {
    path: 'admin/category',
    component: CategoryListComponent
  },
  {
    path: 'admin/category/add',
    component: AddCategoryComponent
  },
  {
    path: 'admin/category/edit/:id',
    component: EditCategoryComponent
  },
  {
    path: 'admin/blogposts',
    component: BlogpostListComponent
  },
  {
    path: 'admin/blogposts/add',
    component: AddBlogpostComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './container/home/home.component';
import { AdminDashboardComponent } from './container/admin-dashboard/admin-dashboard.component';
import { BookAdminComponent } from './container/admin-dashboard/book-admin/book-admin.component';
import { AddBookComponent } from './container/admin-dashboard/book-admin/add-book/add-book.component';
import { AuthorAdminComponent } from './container/admin-dashboard/author-admin/author-admin.component';
import { AddAuthorComponent } from './container/admin-dashboard/author-admin/add-author/add-author.component';
import { CategoryAdminComponent } from './container/admin-dashboard/category-admin/category-admin.component';
import { AddCategoryComponent } from './container/admin-dashboard/category-admin/add-category/add-category.component';
import { EditCategoryComponent } from './container/admin-dashboard/category-admin/edit-category/edit-category.component';
import { EditAuthorComponent } from './container/admin-dashboard/author-admin/edit-author/edit-author.component';
import { EditBookComponent } from './container/admin-dashboard/book-admin/edit-book/edit-book.component';
import { AuthenticationComponent } from './container/authentication/authentication.component';
import { CanActivateAdmin } from './container/authentication/auth.gaurd.service';
import { BooksUserComponent } from './container/books-user/books-user.component';
import { AuthorsUserComponent } from './container/authors-user/authors-user.component';
import { BookUserComponent } from './container/books-user/book-user/book-user.component';
import { OrderConfirmationComponent } from './header/cart/order-confirmation/order-confirmation.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "dashboard" , component:AdminDashboardComponent, canActivate:[CanActivateAdmin] , children:[
    {path:"book" , component:BookAdminComponent },
    {path:"authors" , component:AuthorAdminComponent},
    {path:"category", component:CategoryAdminComponent},
    {path:"addbook" , component:AddBookComponent},
    {path:"addcategory" , component:AddCategoryComponent},
    {path:"addauthors" , component:AddAuthorComponent},
    {path:"editcategory/:id" , component:EditCategoryComponent},
    {path:"editauthor/:id",component:EditAuthorComponent},
    {path:"editbook/:id",component:EditBookComponent},
  ]},
  {path:"books", component:BooksUserComponent},
  {path:"books/:id",component:BookUserComponent},
  {path:"authors" , component:AuthorsUserComponent},
  {path:"auth" , component:AuthenticationComponent},
  {path:"orderConfirmation" , component:OrderConfirmationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

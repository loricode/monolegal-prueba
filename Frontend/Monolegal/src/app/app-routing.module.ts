import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';

//components
import { CustomerComponent } from './customer/customer.component';

const routes: Routes = [
  {
    path: '', component: CustomerComponent, pathMatch: 'full'
  },
  { path: '**', redirectTo:''}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

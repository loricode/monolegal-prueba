import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IBill, IBillDetail } from '../interfaces/bill.interface';

//services
import { CustomerService } from '../services/customer/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent {

  detailBill: IBill = {
    identification: '',
    fullName: '',
    bills: []
  }

  searhForm: FormGroup = this.fb.group({
    identification: ['', [Validators.required]],
    state: ['P'],
  })

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService
  ) { }

  public searchSubmit() {

    this.customerService.getBills(this.searhForm.value).subscribe(res => {
        this.detailBill = res;
      })
  }

  public changeSelect(item: IBillDetail, e:any) {

    const objReq = {
      identification: this.detailBill.identification,
      state: e.target.value,
      idBill: item.idBill
    }

    this.customerService.updateBill(objReq).subscribe(res => {

      const index = this.detailBill.bills.findIndex(x => x.idBill === item.idBill)

      let arrCopy = [...this.detailBill.bills];

      let aux = {...this.detailBill.bills[index]};

      aux.state = e.target.value;

      arrCopy[index] = aux;

      this.detailBill.bills = arrCopy;

    }) 

  }
  
}

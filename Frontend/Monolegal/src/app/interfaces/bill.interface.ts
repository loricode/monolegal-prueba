export interface IBill {
  identification: string,
  fullName: string;
  bills: Array<IBillDetail>
}

export interface IBillDetail {
  idBill: string;
  code: string;
  city: string;
  totalBill: string;
  subTotal: string;
  state: string;
  iva: 3078;
  retention: string;
  creationDate: string
}

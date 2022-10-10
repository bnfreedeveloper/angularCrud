import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import { HttpClient, HttpHeaders } from "@angular/common/http"
@Injectable({
  providedIn: 'root'
})
export class PaymentDetailsService {
  formData: PaymentDetail = new PaymentDetail();
  readonly baseUrl = "https://localhost:5001/api/paymentdetails";
  headers: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT'

  });

  constructor(private http: HttpClient) { }

  sendPaymentDetails() {
    return this.http.post(this.baseUrl, this.formData, { headers: this.headers })
  }
}

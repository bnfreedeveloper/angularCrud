import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentDetailsService } from 'src/app/Shared/payment-details.service';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styleUrls: ['./payment-detail-form.component.css']
})
export class PaymentDetailFormComponent implements OnInit {

  constructor(public paymentService: PaymentDetailsService) { }

  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {
    this.paymentService.sendPaymentDetails().subscribe(() => {
      form.reset();
    })
  }

}

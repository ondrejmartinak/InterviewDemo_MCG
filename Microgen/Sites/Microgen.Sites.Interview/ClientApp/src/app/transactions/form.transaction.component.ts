import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

/** @title Form field theming */
@Component({
  selector: 'form-transaction-component',
  templateUrl: './form-transaction.html',
 // styleUrls: ['form-field-theming-example.css'],
})
export class FormTransactionComponent {
  options: FormGroup;

  constructor(fb: FormBuilder) {
    this.options = fb.group({
      color: 'primary',
      fontSize: [16, Validators.min(10)],
    });
  }

  getFontSize() {
    return Math.max(10, this.options.value.fontSize);
  }
}

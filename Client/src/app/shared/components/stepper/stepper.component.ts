import { CdkStepper, StepperSelectionEvent } from '@angular/cdk/stepper';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.scss'],
  providers: [{provide: CdkStepper, useExisting: StepperComponent}]
})
export class StepperComponent extends CdkStepper  implements OnInit, OnDestroy {

  @Input() linearModeSelected = true;
  @Input() submitLabel = 'Submit';
  @Output() complete = new EventEmitter<any>();
  subscription?: Subscription;
  index = 0;

  ngOnInit(): void {
    this.subscription = this.selectionChange.subscribe({
      next: (value: StepperSelectionEvent) => {
        this.index = value.selectedIndex;
      }
    })
  }

  submitForm() {
    this.complete.emit(true);
  }

  get nextButtonLabel() {
    return this.steps.length === this.index + 1
      ? this.submitLabel
      : 'Go to ' + this.steps.find((_, i) => i === this.index+1)?.label
  }

  override ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}

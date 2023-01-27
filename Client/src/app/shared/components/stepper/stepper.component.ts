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

  ngOnInit(): void {
    this.linear = this.linearModeSelected;
  }

  onClick(index: number) {
    this.selectedIndex = index;
  }
}

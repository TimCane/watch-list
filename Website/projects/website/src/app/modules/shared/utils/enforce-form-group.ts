import { FormControl, FormGroup } from '@angular/forms';

export type Enforce<T extends Record<string, any>> = {
  [K in keyof T]: T[K] extends Record<any, any>
    ? FormGroup<Enforce<T[K]>>
    : FormControl<T[K]>;
};

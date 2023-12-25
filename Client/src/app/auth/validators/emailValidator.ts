import { ValidatorFn } from "@angular/forms";
// error property coded as emailVdtr > example > Form.get('email')?.errors?.['emailVdtr']">

export function emailVdtr(): ValidatorFn {
    const regExp = new RegExp(`^([a-z0-9._%+-]+)@([a-z0-9.-]+)(\.)([a-z]{2,4}$)`);

    return (control) => {
        return control.value === "" || regExp.test(control.value)
            ? null
            : { emailVdtr: true };
    };
}
import { FormGroup, ValidatorFn } from "@angular/forms";

export function matchPasswordsValidator(passControlOne: string, passControlTwo: string): ValidatorFn {
    return (control) => {
        const group = control as FormGroup;

        const p1 = group.get(passControlOne);
        const p2 = group.get(passControlTwo);

        return p1?.value === p2?.value ? null : { matchPasswordsValidator: true };
    };
}

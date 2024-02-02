export interface SpeditionFormData {
    fromAddress: string;
    toAddress: string;
    fromDate: string;
    toDate: string;
    numberOfPallets: number;
    totalWeight: number;
    name: string;
    phoneNumber: string;
    email: string;
}

export interface SpeditionFormDataWithId extends SpeditionFormData {
    status: string,
    id: string
}
export interface TransportFormData {
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

export interface TransportFormDataWithId extends TransportFormData {
    status: string,
    id: string,
    date?: string,
    destination?: string
}
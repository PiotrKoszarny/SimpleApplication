import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

export interface RegisterViewModel {
    email: string;
    password: string;
    confirmPassword: string;
}

export interface UserLoginDto {
    email: string;
    password: string;
}

export interface UserLoginResultDto {
    userId: string;
    email: string;
    isSuccessed: boolean;
    isLocked: boolean;
    loginError: string;
    token: string;
}

export interface AddImgFileDto {
    fileName: string;
    fileType: string;
    photoBytes: string;
}

export interface AddCarDto {
    carId: number;
    brand: string;
    model: string;
    productionDate: string;
    mileage: number;
    photos: AddImgFileDto[];
}

export interface AddCarCommandResult {
    carId: number;
    brand: string;
    model: string;
    productionDate: string;
    mileage: number;
}

export interface GetCarDto {
    carId: number;
    brand: string;
    model: string;
    productionDate: string;
    mileage: number;
    photoUrls: string;
}

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    apiBaseUrl = environment.apiBaseUrl;

    constructor(
        private httpClient: HttpClient
    ) { }

    public async postRegister(data: RegisterViewModel): Promise<any> {

        return this.httpClient.post<any>(this.apiBaseUrl + '/Account/register', data).toPromise();
    }

    public async postSignIn(data: UserLoginDto): Promise<any> {

        return this.httpClient.post<any>(this.apiBaseUrl + '/Account/sign-in', data).toPromise();
    }

}

@Injectable({
    providedIn: 'root'
})
export class CarService {
    apiBaseUrl = environment.apiBaseUrl;

    constructor(
        private httpClient: HttpClient
    ) { }

    public async postCreateCar(data: AddCarDto): Promise<any> {

        return this.httpClient.post<any>(this.apiBaseUrl + '/Car/admin/create-car', data).toPromise();
    }

    public async getCars(): Promise<void |GetCarDto[]> {
        return this.httpClient.get<GetCarDto[]>(this.apiBaseUrl + '/Car/cars').toPromise();
    }

}

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    apiBaseUrl = environment.apiBaseUrl;

    constructor(
        private httpClient: HttpClient
    ) { }

    public async getProduct(): Promise<any> {
        return this.httpClient.get<any>(this.apiBaseUrl + '/Product').toPromise();
    }

}

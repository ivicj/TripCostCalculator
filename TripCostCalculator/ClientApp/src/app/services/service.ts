import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscription } from '../models/subscription.model';
import { CarType } from '../models/carType.model';
import { Price } from '../models/price.model';


@Injectable({
    providedIn: 'root'
})
export class Service {
    constructor(@Inject('API_BASE_URL')
                public baseUrl: string,
                public http: HttpClient) {}

    getSubscriptions() {
        return this.http.get<Subscription[]>(this.baseUrl + '/Subscription');
    }
    
    getCarTypes() {
        return this.http.get<CarType[]>(this.baseUrl + '/CarType');
    }
      
    getPrices() {
        return this.http.get<Price[]>(this.baseUrl + '/Prices');

    }  
}
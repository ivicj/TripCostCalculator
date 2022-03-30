import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Service } from '../services/service';
import { Price } from '../models/price.model';
import { Subscription } from '../models/subscription.model';
import { CarType } from '../models/carType.model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public subscriptionList: Subscription[] = [];
  public carTypeList: CarType[] = [];
  public priceList: Price[] = [];
  form = new FormGroup({
    subscription: new FormControl('', Validators.required),
    carType: new FormControl('', Validators.required),
    tripDuration: new FormControl(''),
    estimatedAmoutKm: new FormControl('')
  });
  public tripCostPerTime = 1;
  public tripCostPerKm = 1;
  
  constructor(private service: Service,
              private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.service.getSubscriptions().subscribe(result => {
        this.subscriptionList = result;
      }, error => console.error(error));
    
    this.service.getCarTypes().subscribe(result => {
        this.carTypeList = result;
      }, error => console.error(error));      

    this.service.getPrices().subscribe(result => {
        this.priceList = result;
      }, error => console.error(error));

    this.form = this.formBuilder.group(
      {
        subscription: ['', Validators.required],
        carType: ['', Validators.required],
        tripDuration: ['', Validators.required],
        estimatedAmoutKm: ['', Validators.required]
      }
    );


  }
   
  submit(){
    if (this.form.invalid) {
      return;
    }

    var price = this.priceList.find(x => x.carTypeId == this.form.value.carType && x.subscriptionId == this.form.value.subscription);
    var pricePerHour = price?.pricePerHour;
    var pricePerKm = price?.pricePerHour;
    
    if(pricePerHour){
      this.tripCostPerTime = this.form.value.tripDuration * pricePerHour;
    }
    if(pricePerKm){
      this.tripCostPerKm = this.form.value.estimatedAmoutKm * pricePerKm;
    }
    return;
  }
}

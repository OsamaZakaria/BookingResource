import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { ResourceDto } from '../models/ResourceDto';
import { FormControl, FormGroup } from '@angular/forms';
import { BookingResourceDto } from '../models/BookingResourceDto';
import { BookResourceService } from '../Services/bookResource.service';
@Component({
  selector: 'bookResourceDialog',
  templateUrl: './bookResourceDialog.component.html'
})

export class BookResourceDialogComponent implements OnInit{
  public bookObject: BookingResourceDto 
  public resource: ResourceDto;

  constructor(@Inject(MAT_DIALOG_DATA) private data: ResourceDto, private alert: MatSnackBar
              ,private bookingService: BookResourceService) {
   this.resource = data;
}  
    ngOnInit(): void {
      console.log(this.bookObject)
      this.bookObject = {dateFrom: null,dateTo: null ,quantity :0, resourceId: this.resource.id};
      
    }

    onSubmit(){
      this.bookingService.create(this.bookObject)
      .subscribe(
        response => {
          this.alert.open(response, 'Success', {
            duration: 2000,
          });
        },
        error => {
          console.log(error);
             this.alert.open(error.error, 'error', {
            duration: 2000,
          });
        });

    }
}
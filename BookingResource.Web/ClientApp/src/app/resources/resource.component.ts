import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ResourceDto } from '../models/ResourceDto';
import { BookResourceDialogComponent } from './bookResourceDialog.component';
import { ResourceService } from '../Services/resource.service';

@Component({
  selector: 'resource',
  templateUrl: './resource.component.html'
})
export class ResourceComponent implements OnInit {
  public resources: ResourceDto[];
  public displayedColumns = ['id', 'name', 'bookResource'];

  constructor(private dialog: MatDialog, private resourceService: ResourceService) {
    this.getResources();
  }
  ngOnInit(): void {
    this.getResources();
  }
  onBookResource(resource) {
    this.dialog.open(BookResourceDialogComponent, {
      data: resource
    });
  }
  getResources() {
    this.resourceService.readAll()
      .subscribe(
        result => {
          this.resources = result;
          console.log(result);
        },
        error => {
          console.log(error);
        });
  }
}

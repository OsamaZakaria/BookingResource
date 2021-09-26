import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs';
import { CollectionViewer } from '@angular/cdk/collections';
import { of } from 'rxjs';

export class SimpleDataSource extends DataSource<any>
{
    constructor (private data: Array<any>)
    {
        super();
    }
    connect(): Observable<any[]> {
        return of(this.data);
    }
    
    disconnect(collectionViewer: CollectionViewer): void {
    }
}
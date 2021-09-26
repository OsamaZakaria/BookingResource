export class PagedItems<T>
{
    constructor() {
        this.Items = new Array();
        this.TotalItemsCount = 0;        
    }
    
    Items : Array<T>;
    TotalItemsCount : number;
}
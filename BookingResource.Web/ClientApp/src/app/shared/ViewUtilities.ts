import { Sort } from '@angular/material';
export class ViewUtilities
{
    public static GetSortString (sort: Sort) : string
    {
        if(sort && sort.active && sort.direction)
        {
            return sort.active + ' ' +sort.direction;
        }
        return '';
    }
}
import { Component} from '@angular/core';
import { ApiService } from '../../core/core-services/api-service/api.service';


// Moved Api service inside core-service folder



@Component({
  selector: 'app-for-us',
  templateUrl: './for-us.component.html',
  styleUrls: ['./for-us.component.css']
})
export class ForUsComponent {

  data:any;
  badRequest: boolean = false;

    constructor(private httpService: ApiService) {}

    ngOnInit() {
      
      this.httpService.getData().subscribe(
        response => { 
          if(response.status !== 200) {
          this.badRequest = true;
        } else {this.data = response.body,
          console.log(this.data);
        }},
        error => {
            this.badRequest = true;
        }
        
        
      ) 
    }
}

import { Component } from '@angular/core';
import { ApiClient } from '../services/api-client';
import { response } from 'express';

@Component({
  selector: 'app-client',
  imports: [],
  templateUrl: './client.html',
  styleUrl: './client.scss'
})
export class Client {

  constructor ( private apiClient : ApiClient ) {

  }

  getAllClients(){
    this.apiClient.getClients().subscribe(request => {
      console.log(request);
    })
  }

  getClientById(id: number){
    this.apiClient.getClient(id).subscribe(request => {
      console.log(request);
    })
  }

  
}

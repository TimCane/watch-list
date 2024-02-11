import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { GeneratedApiClientService } from './generated-api-client.service';

@NgModule({
  imports: [HttpClientModule],
  providers: [ApiClientService, GeneratedApiClientService],
})
export class ApiClientModule {}

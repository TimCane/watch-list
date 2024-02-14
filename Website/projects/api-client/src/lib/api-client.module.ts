import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { GeneratedApiClientService } from './generated-api-client.service';
import { UserService } from './services/user.service';

@NgModule({
  imports: [HttpClientModule],
  providers: [ApiClientService, GeneratedApiClientService, UserService],
})
export class ApiClientModule {}

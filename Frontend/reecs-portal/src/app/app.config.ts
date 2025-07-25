import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './interceptor/auth.interceptor';

export const appConfig = {
  providers: [provideHttpClient(withInterceptors([authInterceptor])),provideRouter(routes)],
};

import { Directive, OnInit, ViewContainerRef, TemplateRef, Input } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective implements OnInit {
  private authorities: string[];

  @Input() appHasRole(value: string | string[]) {
    this.authorities = typeof value === 'string' ? [value] : value;
  }

  constructor(
    private viewContainerRef: ViewContainerRef,
    private templateRef: TemplateRef<any>,
    private authorize: AuthorizeService
  ) { }

  ngOnInit() {
    //  We subscribe to the roles$ to know the roles the user has
    this.authorize.getUser().subscribe(u => {
      let existeRole = false;
      const roles = u.role;
      // If he doesn't have any roles, we clear the viewContainerRef
      if (roles) {
        this.authorities.forEach(i => {
          if (roles.includes(i)) {
            existeRole = true;
          }
        });
      }

      if (existeRole) {
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      } else {
        this.viewContainerRef.clear();
      }
    });
  }






}

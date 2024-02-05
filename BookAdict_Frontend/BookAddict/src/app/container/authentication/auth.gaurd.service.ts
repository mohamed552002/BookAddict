import { inject } from "@angular/core"
import { AuthApis } from "../../server/Auth.services"
import { Observable, map, take } from "rxjs";
import { Router, UrlTree } from "@angular/router";

export const CanActivate = ():boolean | Promise<boolean> | Observable<boolean> =>{
  const authService = inject(AuthApis)
  return authService.user.pipe(map((user) => {
    return !!user
  }))
}

export const CanActivateAdmin = ():boolean | Promise<boolean> | Observable<boolean | UrlTree> =>{
  const authService = inject(AuthApis)
  const router = inject(Router)
  return authService.user.pipe(take(1),map((user) => {
    if(!!user && user.roles.includes("admin"))
      return true
    return router.createUrlTree([""])
  }))
}

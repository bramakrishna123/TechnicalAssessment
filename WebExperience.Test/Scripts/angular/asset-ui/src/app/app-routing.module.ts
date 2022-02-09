import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetDetailComponent } from './components/asset-detail/asset-detail.component';
import { AssetListComponent } from './components/asset-list/asset-list.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "asset-list"
  },
  {
    component: AssetListComponent,
    path: "asset-list"
  },
  {
    component: AssetDetailComponent,
    path: "asset-detail/:id"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

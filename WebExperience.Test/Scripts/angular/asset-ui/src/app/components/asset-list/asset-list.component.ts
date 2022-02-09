import { OnInit } from "@angular/core";
import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AssetService } from "../../services/asset.service";
import { IAsset } from "../../types/asset.model";

@Component({
  selector: "asset-list",
  templateUrl: "./asset-list.component.html",
  styleUrls: ["./asset-list.component.scss"]
})
export class AssetListComponent implements OnInit {
  assetList: IAsset[] = [];
  constructor(private _assetService: AssetService,
    private router: Router) { }

  ngOnInit(): void {
    this._assetService.getAssetServiceList().subscribe((result: IAsset[]) => {
      this.assetList = result;
    },
    err => {
        console.log('Oops!!! Error occured while fetching data')
    });
  }

  onRowSelect(asset: IAsset): void {
    this.router.navigate(['/asset-detail', asset.AssetId]);
  }
}

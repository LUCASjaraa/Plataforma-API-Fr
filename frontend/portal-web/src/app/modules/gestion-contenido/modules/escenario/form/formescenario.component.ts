import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { editEscenariDTO, escenario, slides , addSlide,slideDTO,lat_lng } from '../model/escenario';
import { EscenarioService } from '../service/escenario/escenario.service';

import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {FormControl} from '@angular/forms';
import {MatAutocompleteSelectedEvent} from '@angular/material/autocomplete';
import {MatChipInputEvent} from '@angular/material/chips';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-formescenario',
  templateUrl: './formescenario.component.html',
  styleUrls: ['./formescenario.component.scss']
})


export class FormescenarioComponent implements OnInit {
  escenarioForm!:FormGroup;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  fruitCtrl = new FormControl('');
  filteredFruits: Observable<string[]>;
  fruits: string[] = ['Lemon'];
  allFruits: string[] = ['Apple', 'Lemon', 'Lime', 'Orange', 'Strawberry'];

  @ViewChild('fruitInput') fruitInput!: ElementRef<HTMLInputElement>;

  @Input() editEscenario:escenario = {
    id: "",
    titulo: "",
    short_descrip : "",
    long_descrip: "",
    ciudades: [""],
    slides : [
      {
      slide_id:"",
      titulo:"",
      img_url:"",
      fecha:""
    }
  ],
    lat_long:[{
      lat: 0,
      lng: 0,
    }]
  };


  constructor(
      private readonly fb:FormBuilder,
      private escenarioService:EscenarioService
      )
       {     this.filteredFruits = this.fruitCtrl.valueChanges.pipe(
        startWith(null),
        map((fruit: string | null) => (fruit ? this._filter(fruit) : this.allFruits.slice())),
      );
  }
 // myField = new FormControl()

  ngOnInit(): void {
    this.escenarioForm = this.initForm();
    this.onPatchValue();
   // this.onSetValue();
  }

  onPatchValue():void{
    this.escenarioForm.patchValue(this.editEscenario)
  }


  initForm():FormGroup{
    return this.fb.group({
      titulo:['',[Validators.required]],
      short_descrip:['',[Validators.required]],
      long_descrip:['',[Validators.required]],

      ciudades:this.fb.array([
        this.fb.control("hola",[]),
        this.fb.control("hola",[]),
      ]),
        lat_lng:this.fb.array(this.initFormLatLong()),
    })
  }



  initFormLatLong(): Array<FormGroup>{
    return[
      this.fb.group({
      lat:[0,[Validators.required]],
      lng:[0,[Validators.required]],
    }),
    this.fb.group({
      lat:[0,[Validators.required]],
      lng:[0,[Validators.required]],
    }),
    this.fb.group({
      lat:[0,[Validators.required]],
      lng:[0,[Validators.required]],
    }),
    this.fb.group({
      lat:[0,[Validators.required]],
      lng:[0,[Validators.required]],
    })]
  }


  onSubmit():void{
   this.escenarioService.addEscenarios(this.escenarioForm.value).subscribe(res=>{console.log(res)})
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Add our fruit
    if (value) {
      this.fruits.push(value);
    }

    // Clear the input value
    event.chipInput!.clear();

    this.fruitCtrl.setValue(null);
  }

  remove(fruit: string): void {
    const index = this.fruits.indexOf(fruit);

    if (index >= 0) {
      this.fruits.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.fruits.push(event.option.viewValue);
    this.fruitInput.nativeElement.value = '';
    this.fruitCtrl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.allFruits.filter(fruit => fruit.toLowerCase().includes(filterValue));
  }
}


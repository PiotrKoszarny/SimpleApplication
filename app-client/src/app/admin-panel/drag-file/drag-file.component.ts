import { Component, OnInit, HostBinding, Output, EventEmitter } from '@angular/core';
import { AddImgFileDto } from 'src/app/api/base';

@Component({
  selector: 'app-drag-file',
  templateUrl: './drag-file.component.html',
  styleUrls: ['./drag-file.component.scss']
})
export class DragFileComponent implements OnInit {
  @Output() fileUploaded = new EventEmitter<AddImgFileDto[]>();

  constructor() { }

  ngOnInit() {
  }

  files: AddImgFileDto[] = [];

  uploadFile(event) {

    const reader = new FileReader();
    for (let index = 0; index < event.length; index++) {
      const element = event[index];
      reader.readAsDataURL(element);
      reader.onloadend = () => {
        const file = <AddImgFileDto>{
          fileName: element.name,
          fileType: element.type,
          photoBytes: reader.result.toString().split(',')[1],
        }
        this.files.push(file)
        this.fileUploaded.emit(this.files);
      }

    }
  }

  deleteAttachment(index) {
    this.files.splice(index, 1)
    this.fileUploaded.emit(this.files);
  }
}

import { Component, OnInit, HostListener, HostBinding, Output, EventEmitter } from '@angular/core';
import { ImgFile } from 'src/app/base/models/ImgFile';

@Component({
  selector: 'app-drag-file',
  templateUrl: './drag-file.component.html',
  styleUrls: ['./drag-file.component.scss']
})
export class DragFileComponent implements OnInit {
  @Output() fileUploaded = new EventEmitter<ImgFile[]>();

  constructor() { }

  ngOnInit() {
  }

  files: ImgFile[] = [];

  uploadFile(event) {

    const reader = new FileReader();
    for (let index = 0; index < event.length; index++) {
      const element = event[index];
      reader.readAsDataURL(element);
      reader.onloadend = () => {
        const file = <ImgFile>{
          fileName: element.name,
          fileType: element.type,
          value: reader.result.toString().split(',')[1],
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

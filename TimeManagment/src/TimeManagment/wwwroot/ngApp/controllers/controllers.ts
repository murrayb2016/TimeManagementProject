namespace TimeManagment.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class ContactController {
        public message = 'Hello from the contact page!';
    }


    export class ToDoListController {

        public index: number;
        public totalTime: number = 0;

        public form;

        public categoryName;
        public description;
        public startDate;
        public dueDate;
        public timeEstimate;
        public priorityLevel;

        public constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('api/todoTask')
                .then((response) => {
                    this.form = response.data;
                })  
        }
        addForm(form) {
            this.$http.post('/api/todoTask', form)
                .then((response) => {
                    this.$state.reload();
                })       
        }

        hideCheck = true;
        hideDelete = true;  //hides check boxes and buttons
        hideComplete = true;
        hideEdit = true;
        hideCancel = true;
        hideFormCancel = false;
        hideEditInfo = true;
        hideFormEdit = false;

        hideEditButton() {
            this.hideEdit = false;
            this.hideCheck = false;
            this.hideCancel = false;
            this.hideFormCancel = false;
            this.hideDelete = true;
            this.hideComplete = true;
        }
        hideDeleteButton() {   //toggles for hideCheck
            this.hideDelete = false;
            this.hideCheck = false;
            this.hideCancel = false;
            this.hideFormCancel = false;
            this.hideComplete = true;
            this.hideEdit = true;
        }
        hideCompleteButton() {
            this.hideCheck = false;
            this.hideComplete = false;
            this.hideCancel = false;
            this.hideFormCancel = false;
      
            this.hideDelete = true;
            this.hideEdit = true;
        }
        hidden = true;  //add hide&show 
        toggle() {   //NEEDS TO clears form as well
            this.hidden = !this.hidden;
      
        }
        hide() {  //with no clear
            this.hidden = !this.hidden;
         
        }     
        checked(index: number) {
            this.index = index;
        }
        sumCategories(category) {   //sums by category 
            let sum = 0;
            for (let i in this.form) {
                if (this.form[i].categoryName == category) {
                    sum += this.form[i].timeEstimate;
                }                
            }
            return sum;
        }
        sum() {
            let sum = 0;
            for (let i in this.form) {
                sum += this.form[i].timeEstimate;
       
            }
            this.totalTime = sum;
            return sum;
        }
        Delete() {
   
            this.hideCheck = true;
            this.hideDelete = true;
            this.hideCancel = true;
            this.hideFormCancel = false;
   
                this.$http.delete(`api/todoTask?Task=${this.form[this.index].description}&Category=${this.form[this.index].categoryName}`)
                    .then((response) => {
                        this.$state.reload();
                    })
        }
        Complete() {

            this.hideComplete = true;
            this.hideCheck = true;
            this.hideCancel = true;
            this.hideFormCancel = false;
           
            this.$http.delete(`api/todoTask?Task=${this.form[this.index].description}&Category=${this.form[this.index].categoryName}`)
                .then((response) => {
                    this.$state.reload();
                })
        }
        Edit(form) {
            this.hideEdit = true;
            this.hideCheck = true;
            this.hideCancel = true;
            this.hideFormCancel = true;
            this.hideEditInfo = false;
            this.hideFormEdit = true;

            this.toggle();

            this.categoryName = this.form[this.index].categoryName;
            this.description = this.form[this.index].description;
            this.startDate = this.form[this.index].startDate;
            this.dueDate = this.form[this.index].dueDate;
            this.timeEstimate = this.form[this.index].timeEstimate;
            this.priorityLevel = this.form[this.index].priorityLevel;

            document.getElementById("buttonForm").hidden = true;
            document.getElementById("buttonForm1").hidden = true;
            document.getElementById("buttonForm2").hidden = true;
            document.getElementById("buttonForm3").hidden = true;

            this.$http.post('/api/todoTask', form)
                .then((response) => {
                    this.$http.delete(`api/todoTask?Task=${this.form[this.index].description}&Category=${this.form[this.index].categoryName}`)
                        .then((response) => {
                            this.$state.reload();
                        })          
                })
        }
        Cancel() {
            this.hideCheck = true;
            this.hideDelete = true;
            this.hideComplete = true;
            this.hideEdit = true;
            this.hideCancel = true;
            this.hideFormCancel = false;
        }
    }

 

    //end of editing

}



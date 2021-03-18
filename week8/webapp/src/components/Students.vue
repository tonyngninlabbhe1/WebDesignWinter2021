<template>
    <div>
            <head>
                <title>Page Title</title>
            </head>
            <div v-if='operation == "list"'>
            <body>
                <h2 class="section-heading">Student Table</h2>
                <table style="width: 100%">
                <thead>
                    <tr>
                        <th>Student ID</th>
                        <th>Email Address</th>
                    </tr>
                </thead>
                <tbody id="studentTable">
                        <tr v-for="student in students" :key="student.studentID">
                            <td>{{ student.studentId }}</td>
                            <td>{{ student.email_address }}</td>
                            <td>
                                <button v-on:click='displayUpdateStudent(student.studentID)'>Update</button>
                                <button v-on:click='deleteStudent(student.studentID)'>Delete</button>
                            </td>
                        </tr>
                </tbody>
                </table>
                <button id='addBtn' v-on:click='displayAddStudent()'>Add Student</button> 
            </body> 
            </div>

            <div v-if='operation == "add"'>
                <h2 class='section-heading'>Add Student</h2>
            
                <form>
                    <div class='form-entry'>
                        StudentID: <input type='text' v-model='studentID'/>
                    </div>

                    <div class='form-entry'>
                        emailAddress: <input type='text' v-model='emailAddress'/>
                    </div>

                    <div class='form-entry'>
                        <button v-on:click='addStudent'>Add Student</button>
                        <button v-on:click='cancel'>Cancel</button>
                    </div>
                </form>
            </div>

            <div v-if='operation == "update"'>
                <h2 class='section-heading'>Update Student</h2>
            
                <form>
                    <div class='form-entry'>
                        studentID: <input type='text' v-model='studentID'/>
                    </div>

                    <div class='form-entry'>
                        emailAddress: <input type='text' v-model='emailAddress'/>
                    </div>

                    <div class='form-entry'>
                        <button v-on:click='updateStudent'>Student Product</button>
                        <button v-on:click='cancel'>Cancel</button>
                    </div>
                </form>
         </div>
 
    </div>
</template>

<script>
    import Vue from 'vue';

    export default {
        name: 'students',
        
        data () {
            return {
                students: [],
                operation: 'list',
                studentID: undefined,
                emailAdress: undefined,
                studentUpdateId: undefined,
                apiServer: process.env.VUE_APP_API_SERVER
            }
        },

        methods: {
            getStudents: function() {
                let url = `http://${this.apiServer}/api/student/`;

                Vue.axios.get(url).then(
                    (response) => {
                        this.students = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            getStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}/`;

                Vue.axios.get(url).then(
                    (response) => {
                        this.emailAdress = response.data.emailAdress;
                        this.studentID = response.data.studentID;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            displayAddStudent: function() {
                this.studentID = undefined;
                this.emailAdress = undefined;

                this.operation = 'add';
            },

            addStudent: function() {
                let url = `http://${this.apiServer}/api/student`;

                Vue.axios.post(url, {
                    studentID: this.studentID,
                    emailAdress: this.emailAdress
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            displayUpdateStudent: function(studentId) {
                this.studentUpdateId = studentId;
                this.getStudent(studentId);

                this.operation = 'update';
            },

            updateStudent: function() {
                let url = `http://${this.apiServer}/api/student/${this.studentUpdateId}`;

                Vue.axios.put(url, {
                    studentID: this.studentID,
                    emailAdress: this.emailAdress
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            deleteStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}`;

                Vue.axios.delete(url).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            cancel: function() {
                this.operation = 'list';
            }
        },

        mounted() {
            this.getStudents();
            this.operation = 'list';
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    #first-section{
        font-size: 16pt;
        color: blue
    }

    #second-section{
        font-size: 16pt;
        color:greenyellow
    }
    #third-section{
        font-size: 16pt;
        color:purple
    }


    p {
        color: red;
        text-align: center;
    }

    a {
        font-family: monospace;
        font-weight: bold;
        font-size: 14pt;
    }

    .links {
        background-color: lightgray;
        margin-top: 20px;
        padding: 10px;
    }

    span {
        padding-right: 20px;
    }
</style>
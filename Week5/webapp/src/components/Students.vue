<template>
    <div>
            <head>
                <title>Page Title</title>
            </head>
            <body>
                <h1>Student Table</h1>
                <table style="width: 100%">
                <thead>
                    <th>Student ID</th>
                    <th>Email Address</th>
                </thead>
                <tbody id="studentTable">
                        <tr v-for="student in students" v-bind:key="student">
                            <td>{{ student.studentID }}</td>
                            <td>{{ student.emailAddress }}</td>
                        </tr>
                </tbody>
                </table>

            </body>    
    </div>
</template>

<script>
export default {
  name: 'Students',
  mounted() {
      this.students = getStudents();
  },
  data () {
      return {
          students: []
      }
  }
}
  
  function getStudents() {
      return JSON.parse(students);
  }
    
    var students = '{"students": [{"studentID": "48631", "emailAddress": "mike_@test.com" }, {"studentID": "54613", "emailAddress": "jane_@test.com" }]}';  

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
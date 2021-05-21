import React, {useEffect, useState} from 'react';
import { View, StyleSheet, Image, Text } from 'react-native';




function TeacherSummaryScreen({teacher}) {
    

    return (
        <View style={styles.container}>
            <View style={styles.teacherContainer}>
                <Image source={{uri: teacher?.profilePictureSource}} style={styles.image}></Image>
                <View style={styles.teacherAttributes}>
                    <Text>{teacher?.name}</Text>
                    <Text>{teacher?.age}</Text>
                    <Text>{teacher?.subjects}</Text>
                </View>
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    image: {
        width: 100,
        height: 100
    },
    teacherAttributes: {
        height: 100
    },
    teacherContainer: {
        flex: 1,
        flexDirection: 'row',
        alignItems: 'center',
        alignContent: 'center',
    },
    container: {
        height: 100,
        flex: 1,
        flexDirection: 'row'
    }
})

export default TeacherSummaryScreen;
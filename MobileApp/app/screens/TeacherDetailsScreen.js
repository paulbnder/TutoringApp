import React from 'react';
import { AntDesign } from '@expo/vector-icons';
import { StyleSheet, View } from 'react-native';
import { useTheme } from '@react-navigation/native';
import * as Haptics from 'expo-haptics';
import { Avatar, Text } from 'react-native-elements';
import TextArea from '../components/TextArea';





function TeacherDetailsScreen({ navigation, route }) {
    const { margin, colors } = useTheme();
    const { teacher } = route.params;


    const goBack = () => {
        navigation.goBack();
        Haptics.selectionAsync();
      };

    const styles = StyleSheet.create({
        closeIcon: {
            zIndex: 10,
            top: margin,
            right: margin,
            opacity: 0.75,
            color: colors.text,
            position: 'absolute',
          },
        container: {
            top: 40,
            alignItems: 'center',
            padding: 10
        },
    })

    return (
        <View >
            <AntDesign size={27} name="close" onPress={goBack} style={styles.closeIcon} />
            <View style={styles.container}>
                <Avatar
                    source={{
                        uri:teacher.profilePictureSource
                    }}
                    size = "xlarge"
                    rounded
                    >
                </Avatar>
                <Text h3>{teacher.name}</Text>
                <TextArea title='About me' text={teacher.aboutMeText}></TextArea>
                <TextArea title='I can teach' text={teacher.subjects.join(', ')}></TextArea>
                <TextArea title='Age' text={teacher.age}></TextArea>
            </View>
        </View>
    );
}

export default TeacherDetailsScreen;